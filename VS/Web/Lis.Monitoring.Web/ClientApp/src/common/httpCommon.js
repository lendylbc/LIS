import axios from "axios";

export default axios.create({
    baseURL: "https://localhost:44336/api/",
    //baseURL: "https://172.16.205.243/api/",
    //baseURL: "http://172.16.205.243:90",

    //baseURL: "https://dohled.liberec.cz/api/",
    

    //httpsAgent: new https.Agent({
    //    rejectUnauthorized: false
    //}),
  headers: {
      "Content-type": "application/json",
      'Access-Control-Allow-Origin': '*'
  }
});