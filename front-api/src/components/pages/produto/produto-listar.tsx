import { useEffect, useState } from "react";
import { Produto } from "../../../models/Produto";
import axios from "axios";

function ProdutoListar() {
  const [produtos, setProdutos] = useState<Produto[]>([]);

  useEffect(() => {
    carregarProdutos();
  }, []);

  function carregarProdutos() {
    fetch("http://localhost:5088/produto/listar").then((resposta) =>
      resposta.json().then((produtos: Produto[]) => {
        setProdutos(produtos);
        console.table(produtos.map);
      })
    );
  }
  function deletar(id: string) {
    alert("ID: " + id);
    axios
      .delete(`http://localhost:5088/produto/deletar/${id}`)
      .then((resposta) => {console.log(resposta.data);
    setProdutos(resposta.data);
      });
  }
  return (
    <div>
      <br></br>
      <h2>Produtos</h2>
      <table border={1}>
        <thead>
          <tr>
            <th>#</th>
            <th>Nome</th>
            <th>Descricao</th>
            <th>Valor</th>
            <th>Quantidade</th>
            <th>Criado Em</th>
          </tr>
        </thead>
        <tbody>
          {produtos.map((produto) => (
            <tr key={produto.id}>
              <td>{produto.id}</td>
              <td>{produto.nome}</td>
              <td>{produto.descricao}</td>
              <td>{produto.valor}</td>
              <td>{produto.quantidade}</td>
              <td>{produto.criadoEm}</td>
              <td>
                <button
                  onClick={() => {
                    deletar(produto.id!);
                  }}
                >
                  Deletar
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
export default ProdutoListar;
