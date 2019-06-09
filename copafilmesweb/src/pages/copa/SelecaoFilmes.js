import React, { Component } from "react";
import {PageHeader} from '../../commons/index';
import {getList, postCopaFilmes} from './SelecaoFilmesService';
import {Card, CardBody, CardTitle, CardSubtitle, CardText, Button} from 'reactstrap';


export default class SelecaoFilmes extends Component {
    constructor(props) {
        super(props);
        this.state = {
          data: [],
          participante: [],
          selecionados: 0          
        };        
        this.token = "123";
    
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
                if (data[i].id  == e.target.value) {
                    this.state.participante.push(data[i]);
                }
            }
            this.state.selecionados = this.state.selecionados + 1; 
        }else
        {
            for (var i = 0; i < participante.length; i++) {
                if (participante[i].id  == e.target.value) {
                    participante.splice(i, 1);
                }
            }
        }
    }

    handleSubmit(e) {
        e.preventDefault();
        let list = this.state.participante
        postCopaFilmes(list)
          .then(data =>
            console.log('deu bom', data, e)
          )
          //.catch(error => this.handleError(error));       
    }

    render() {
        return (
            <div className='center col-12'>
                <PageHeader title="Fase de Seleção" descricao = "selecione 8 Filmes que você deseja "/>
                <div className="row col-12">
                    <p>{this.state.selecionados} de 8 selecionados</p>
                    
                    <Button
                    className
                    type="button"
                    color="sucess margin-left"
                    onClick={this.handleSubmit}>GERAR MEU CAMPEONATO
                    </Button>
                </div>
                <div className="row justify-content-center">
                    {
                        this.state.data.map((item, i) => (
                            <Card className ='col-3'>
                            <CardBody>
                            <input
                                className="col-1"
                                value = {item.id}
                                onChange={this.handleChangeCk}
                                type="checkbox" />
                            <CardTitle>{item.titulo}</CardTitle>
                            <CardSubtitle>{item.ano}</CardSubtitle>
                            <CardText></CardText>                            
                            </CardBody>
                            </Card>
                        ))                        
                    }
                </div>
            </div>
        )
    }
}