import {api_lambda} from "../../services/api";

export const getList = () => {
  const url = `filmes`;
  return new Promise((resolve, reject) => {
    api_lambda
      .get(url, { headers: {'Access-Control-Allow-Origin': '*'} })
      .then(response => resolve(response.data))
      .catch(error => reject(error.response));
  });
};
