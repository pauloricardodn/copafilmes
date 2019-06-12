import React from 'react';
import "./index.css";

export const ButtonAction = (props) => {
  return (<button className={props.class}>{props.name}</button>);
}

export const PageHeader = (props) => {
  return (
    <div className="pageHeader">
      <p className="subTitulo">CAMPEONATO DE TIMES</p> 
      <h1 className="">{props.title}</h1>
      <p className="linha"><strong>___</strong></p>
      <div className="row center">
        <p className="col-6"><strong>{props.descricao}</strong></p>
      </div>      
    </div>
  );
}