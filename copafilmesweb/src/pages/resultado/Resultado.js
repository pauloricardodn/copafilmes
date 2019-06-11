import React, { Component } from "react";
import {PageHeader} from '../../commons/index';
import {Card, CardBody, CardTitle} from 'reactstrap';

export default class Resultado extends Component {
    constructor(props) {
        super(props);
        this.state = {
          Resultado: props.location.state        
        };
        var cont = 1; 
    } 
    render() {
      console.log(this.props)
      return (
        <div className='container col-11'>
          <PageHeader title="Resultado" descricao = "selecione 8 Filmes que você deseja "/>
          <div className="row">
            {
              this.state.Resultado.map((item, i) => (
                <Card className ="col-12">                
                <CardBody className="row">
                  <div className="col-1">
                  </div>
                  <div>
                    <CardTitle><b> {item.titulo}</b></CardTitle>
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