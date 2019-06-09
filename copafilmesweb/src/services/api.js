import axios from "axios";

export const api_lambda = axios.create({
  baseURL: 'https://copadosfilmes.azurewebsites.net/api/'
});

const api = axios.create({
  baseURL: 'http://localhost:62877/api/v1.0/'
});

export default api;