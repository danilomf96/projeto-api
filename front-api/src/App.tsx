import React from "react";
import ProdutoCadastrar from "./components/pages/produto/produto-cadastrar";
import ProdutoListar from "./components/pages/produto/produto-listar";
import { BrowserRouter, Link, Route, Routes } from "react-router-dom";

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <nav>
          <ul>
            <li>
              <Link to={"/"}>Home</Link>
            </li>
            <li>
              <Link to={"pages/produto/listar"}>Listar Produtos</Link>
            </li>
            <li>
              <Link to={"pages/produto/cadastrar"}>Cadastrar Produtos</Link>
            </li>
          </ul>
        </nav>
        <Routes>
          <Route path="/" element={<ProdutoListar />} />
          <Route path="/pages/pruduto/listar" element={<ProdutoListar />} />
          <Route
            path="/pages/produto/cadastrar"
            element={<ProdutoCadastrar />}
          />
        </Routes>
      </BrowserRouter>
      <footer>
        <p>Desenvolvido por Danilo</p>
      </footer>
    </div>
  );
}

export default App;
