using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Lis.Monitoring.Shared.Helper {
	public static class PasswordHelper
	{
		/// <summary>
		/// Generuje hash z hesla
		/// </summary>
		/// <param name="password">Heslo, které má být zahešované</param>
		/// <param name="salt">Sůl, která byla použita k vygenerování hesla</param>
		/// <returns></returns>
		public static string GeneratePasswordHash(string password, out byte[] salt) {

			salt = new byte[128 / 8];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(salt);
			}

			return GetPasswordHash(password, salt);
		}

		/// <summary>
		/// Zkontroluje, jestli je dané heslo shodné se zadaným při registraci
		/// </summary>
		/// <param name="password">Heslo zadané uživatelem k ověření</param>
		/// <param name="passwordHash">Hash hesla zadaného při "registraci"</param>
		/// <param name="salt">Sůl použitá k vytvoření hashe při prvním vygenerování</param>
		/// <returns>Tru v případě, že jsou hesla shodná, jinak false</returns>
		public static bool IsPasswordRight(string password, string passwordHash, byte[] salt) {
			return passwordHash == GetPasswordHash(password, salt);
		}

		/// <summary>
		/// Vygeneruje hash z hesla
		/// </summary>
		/// <param name="password">Heslo</param>
		/// <param name="salt">Sůl</param>
		/// <returns>Hash hesla</returns>
		private static string GetPasswordHash(string password, byte[] salt) {
			string passwordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: password,
				salt: salt,
				prf: KeyDerivationPrf.HMACSHA256,
				iterationCount: 10000,
				numBytesRequested: 256 / 8));

			return passwordHash;
		}
	}
}