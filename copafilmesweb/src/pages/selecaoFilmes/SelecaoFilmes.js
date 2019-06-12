import React, { Component } from "react";
import {PageHeader} from '../../commons/index';
import {getList, postCopaFilmes} from './SelecaoFilmesService';
import {Card, CardBody, CardTitle, CardSubtitle, CardText, Button} from 'reactstrap';
import SweetAlert from 'sweetalert2-react';
import './SelecaoFilmes.css';


export default class SelecaoFilmes extends Component {
  constructor(props) {
      super(props);
      this.state = {
        data: [],
        participante: [],
        selecionados: 0 ,
        alert:{
          show:false,
          title:"",
          text:""
        }         
      };  
      this.getEventList = this.getEventList.bind(this);
      this.handleChangeCk = this.handleChangeCk.bind(this);
      this.handleSubmit = this.handleSubmit.bind(this);
  }
  componentWillMount() {
      this.getEventList();
  }
  getEventList() {
      getList()
        .then(data =>
          this.setState({
            data: data
          })
      )
  }
  handleChangeCk(e) {
    let {data, participante} = this.state;
    if(e.target.checked)
    {
      for (var i = 0; i < data.length; i++) {
        if (data[i].id  === e.target.value) {
          this.state.participante.push(data[i]);
        }
      }
      this.setState({
        ...this.state,
        selecionados: this.state.selecionados + 1
      });
    }else
    {
      for (var i = 0; i < participante.length; i++) {
        if (participante[i].id  === e.target.value) {
          participante.splice(i, 1);
        }
      }
    this.setState({
        ...this.state,
        selecionados: this.state.selecionados - 1
      });
    }
  }

  handleSubmit(e) {
    e.preventDefault();    
    let list = this.state.participante
    if(list.length ===8){     
      postCopaFilmes(list)
      .then(data =>
         this.props.history.push({
          pathname:"/Resultado",
          state: data
        }) 
      );     
    }else if(list.length < 8){
      this.setState({
        ...this.state,
        alert:{
          show: true,
          title: "Alerta",
          text: "Voce deve selecionar 8 Filmes."        
        }
      })
    }else{
      this.setState({
        ...this.state,
        alert:{
          title: "Alerta",
          text: "Voce não pode selecionar mais de 8 Filmes.",
          show: true
        }
      })
    }       
  }
  render() {
    return (
      <div className='container col-11'>
        <PageHeader title="Fase de Seleção" descricao = "Selecione 8 Filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir."/>
        <div className="row col-12 espaco">
          <p className="contador">Selecionados {this.state.selecionados} de 8 Filmes</p>        
          <Button
          className ="rigth"
          type="button"
          color="dark margin-left"
          onClick={this.handleSubmit}>GERAR MEU CAMPEONATO
          </Button>          
        </div>
        <div className="row center">
          {
            this.state.data.map((item, i) => (
              <Card className ='divCard card-selecao' key = {item.id}>
              
              <CardBody className="row">
                <div className="col-2">
                  <input                  
                  value = {item.id}
                  onChange={this.handleChangeCk}
                  type="checkbox" />
                </div>
                <div className = "cardDivText">
                  <CardTitle><b>{item.titulo}</b></CardTitle>
                  <CardText>{item.ano}</CardText>
                </div>                        
              </CardBody>
              </Card>
            ))                        
          }
        </div>
        <div>      
          <SweetAlert
             show={this.state.alert.show}
             title={this.state.alert.title}
             text={this.state.alert.text}
             onConfirm={() => this.setState({alert:{show: false}})}
          />
        </div>
      </div>
    )
  }
}