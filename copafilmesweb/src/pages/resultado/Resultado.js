import React, { Component } from "react";
import {PageHeader} from '../../commons/index';
import {Card, CardBody, CardTitle} from 'reactstrap';
import './Resultado.css';

export default class Resultado extends Component {
    constructor(props) {
        super(props);
        this.state = {
          Resultado: props.location.state        
        };
        var cont = 1; 
    } 
    render() {
      return (
        <div className='container col-11'>
          <PageHeader title="Resultado Final" descricao = "Veja o resultado final do Campeonato de filmes de forma simples e rapida"/>
          <div className="row">
            {
              this.state.Resultado.map((item, i) => (
                <Card className ="col-12 card-result" key ={item.id}>                
                <CardBody className ="row">
                  <div className="col-1 divPosicao posicao">
                   <p> {i + 1}º </p>
                  </div>
                  <div className ="col-10 divDescricao">
                    <CardTitle>{item.titulo}</CardTitle>
                  </div>                        
                </CardBody>
                </Card>
              ))                        
            }
          </div>          
        </div>
      )
    }
  }