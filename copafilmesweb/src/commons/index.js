import React from 'react';
import "./index.css";

export const ButtonAction = (props) => {
  return (<button className={props.class}>{props.name}</button>);
}

export const PageHeader = (props) => {
  return (
    <div className="pageHeader">
      <p className="">CAMPEONATO DE TIMES</p> 

      <h1 className="">{props.title}</h1>

      <p className="">{props.descricao}</p>
    </div>
  );
}