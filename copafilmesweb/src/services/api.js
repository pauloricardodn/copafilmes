import axios from "axios";

export const api_lambda = axios.create({
  baseURL: 'https://copadosfilmes.azurewebsites.net/api/'
});

const api = axios.create({
  baseURL: 'http://oseventos.azurewebsites.net/api/v1.0/'
});

export default api;