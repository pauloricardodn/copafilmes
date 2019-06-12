import api,{api_azure} from "../../services/api";

export const getList = () => {
  const url = `filmes`;
  return new Promise((resolve, reject) => {
    api_azure
      .get(url, { headers: {'Access-Control-Allow-Origin': '*'} })
      .then(response => resolve(response.data))
      .catch(error => reject(error.response));
  });
};

export const postCopaFilmes = (list) => {
  const url = `CopaFilmes`;
  return new Promise((resolve, reject) => {
      api
          .post(url, list)
          .then(response => resolve(response.data))
          .catch(error => reject(error.response));
  });
};
