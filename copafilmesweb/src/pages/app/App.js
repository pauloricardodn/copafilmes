import React from 'react';
import {BrowserRouter, Router, Route, Switch} from 'react-router-dom';
import SelecaoFilmes from '../copa/SelecaoFilmes';
import '../../App.css';

function App() {
  return (
    <div className="App center">
      <BrowserRouter>
        <Switch>
          <Route path="/" component={SelecaoFilmes}/>
          {/* <Route path="/selecaofilmes" component={SelecaoFilmes}/> */}
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
