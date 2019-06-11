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
          //onConfirm:() => this.setState({show: false })
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
        this.props.history.push("/Resultado")
        // this.props.history.push({
        //   pathname:"/Resultado",
        //   state: data
        //}) 
      );
      //.catch(error => this.handleError(error));      
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
        <PageHeader title="Fase de Seleção" descricao = "selecione 8 Filmes que você deseja "/>
        <div className="row col-12">
          <div className="col-md-4">
            <p>{this.state.selecionados} de 8 selecionados</p>
          </div>
          <div className="col-4">
          </div>
          <div className="col-4">
            <Button
            className ="rigth"
            type="button"
            color="secondary margin-left"
            onClick={this.handleSubmit}>GERAR MEU CAMPEONATO
            </Button>
          </div>
        </div>
        <div className="row">
          {
            this.state.data.map((item, i) => (
              <Card className ='divCard' key = {item.id}>
              
              <CardBody className="row">
                <div className="col-1">
                  <input                  
                  value = {item.id}
                  onChange={this.handleChangeCk}
                  type="checkbox" />
                </div>
                <div>
                  <CardTitle><b>{item.titulo}</b></CardTitle>
                  <CardSubtitle>{item.ano}</CardSubtitle>
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