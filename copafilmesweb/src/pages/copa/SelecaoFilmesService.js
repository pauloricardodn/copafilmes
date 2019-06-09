import api,{api_lambda} from "../../services/api";

export const getList = () => {
  const url = `filmes`;
  return new Promise((resolve, reject) => {
    api_lambda
      .get(url, { headers: {'Access-Control-Allow-Origin': '*'} })
      .then(response => resolve(response.data))
      .catch(error => reject(error.response));
  });
};

export const postCopaFilmes = (list) => {
  const url = `CopaFilmes`;
  console.log('service');
  return new Promise((resolve, reject) => {
      api
          .put(url, list)
          .then(response => resolve(response.data))
          .catch(error => reject(error.response));
  });
};
