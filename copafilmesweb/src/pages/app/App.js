import React from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import SelecaoFilmes from '../selecaoFilmes/SelecaoFilmes';
import Resultado from '../resultado/Resultado';
import '../../App.css';

function App() {
  return (
    <div className="App center">
      <BrowserRouter>
        <Switch>
          <Route path="/" component={SelecaoFilmes}/>
          <Route path="/Resultado" component={Resultado}/>
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
