import { useEffect } from "react";

/* 
  Consultar os produtos da API e exibir na tela
  Resolver problema de CORS
  Como exibir um Array na tela utilizando React
*/

function ProdutoListar() {
  //Executar algum codigo no carregamento do componente
  useEffect(() => {
    console.log("O componente foi carregado");
    //FETCH ou AXIOS
    fetch("https://viacep.com.br/ws/01001000/json/").then((resposta) =>
      resposta.json().then((cep) => {
        console.log(cep);
      })
    );
  }, []);

  return (
    <div>
      <h1>Listar Produtos</h1>
    </div>
  );
}
export default ProdutoListar;
