import React from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import SelecaoFilmes from '../selecaoFilmes/SelecaoFilmes';
import Resultado from '../resultado/Resultado';
import '../../App.css';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Switch>
          <Route exact path="/" component={SelecaoFilmes}/>
          <Route exact path="/Resultado" component={Resultado}/>
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
