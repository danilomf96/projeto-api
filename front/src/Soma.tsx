import { throws } from "assert";
import React, { useState } from "react";

//1 - Exibir o valor do contador no HTML
//2 - Somar os dois numeros da caixa de texto e exibir no navegador

function Soma() {
  const [contador, setContador] = useState(0);
  const [numero1, setNumero1] = useState("");
  const [numero2, setNumero2] = useState("");
  const [resultado, setResultado] = useState(0);

  function incrementarContador() {
    setContador(contador + 1);
    console.log(contador);
  }

  function escreverNumero1(e: any) {
    setNumero1(e.target.value);
  }
  /*function escreverNumero2(e : any) {
      setNumero2(e.target.value);
    }*/
  function somar(){
    setResultado(parseInt(numero1) + parseInt(numero2));
  }
  return (
    <div>
      <h1>Soma</h1>
      <label>Numero 1:</label>
      <input type="text" onChange={escreverNumero1} />
      <br />
      <label>Numero 2:</label>
      <input type="text" onChange={(e: any) => setNumero2(e.target.value)} />
      <br />
      <button onClick={incrementarContador}>Contador</button>
      <br />
      <button onClick={somar}>Somar</button>
      <br />
      <p>{contador}</p>
      <p>{resultado}</p>
    </div>
  );
}

export default Soma;
