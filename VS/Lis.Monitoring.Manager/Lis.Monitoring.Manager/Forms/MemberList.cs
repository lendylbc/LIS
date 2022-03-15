using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lis.Monitoring.Api;
using Lis.Monitoring.Dto.Communication;
using Lis.Monitoring.Dto.Core;
using Lis.Monitoring.Manager.Edits;

namespace Lis.Monitoring.Manager.Forms {
	public partial class MemberList : Form {
		private ApiController _apiController;
		public MemberList(ApiController apiController) {
			_apiController = apiController;
			InitializeComponent();			
		}

		private void DesignMemberGrid() {
			grdMembers.Columns["Id"].Visible = false;
			grdMembers.Columns["Password"].Visible = false;
			grdMembers.Columns["SendNotifications"].Visible = false;
			grdMembers.Columns["MemberType"].Visible = false;
			grdMembers.Columns["Inserted"].Visible = false;
		}

		private void RefreshGrid() {
			GetMemberList();
		}

		private void GetMemberList() {
			PagedResponse<MemberDto> result = _apiController.GetMemberList();
			if(result != null) {				
				grdMembers.DataSource = result.Data;
			} else {
				grdMembers.DataSource = null;
			}
		}

		private void grdMembers_DataSourceChanged(object sender, EventArgs e) {
			DesignMemberGrid();
		}

		private void MemberList_Load(object sender, EventArgs e) {
			RefreshGrid();
		}

		private void btnInsert_Click(object sender, EventArgs e) {
			EditMember(null);
		}

		private void btnEdit_Click(object sender, EventArgs e) {
			EditMember((MemberDto)grdMembers.CurrentRow.DataBoundItem);
		}

		private void btnDelete_Click(object sender, EventArgs e) {
			if(grdMembers.SelectedCells.Count > 0) {
				if(MessageBox.Show("Přejete si smazat zařízení?", Lis.Monitoring.Manager.Properties.Resources.Dotaz, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
					MemberDto MemberDto = (MemberDto)grdMembers.CurrentRow.DataBoundItem;
					try {
						_apiController.DeleteMember((long)MemberDto.Id);
						RefreshGrid();
					} catch {
						MessageBox.Show("Zařízení nelze smazat." + Environment.NewLine +
							"Pravděpodobně má podřízené záznamy.", Lis.Monitoring.Manager.Properties.Resources.Chyba, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}

		private void EditMember(MemberDto MemberDto) {
			using(MemberEdit edt = new MemberEdit(MemberDto, _apiController)) {
				if(edt.ShowDialog() == DialogResult.OK) {
					if(MemberDto != null) {
						RefreshGrid();
					} else {
						RefreshGrid();
					}
				}
			}
		}
	}
}
