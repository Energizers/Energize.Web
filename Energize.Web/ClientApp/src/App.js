import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import Layout from './components/Layout';
import Documentation from './components/Documentation';
import Home from './components/Home';
import WIP from './components/WIP';

export default class App extends React.Component {
    displayName = App.name

    render() {
        return (
            <BrowserRouter>
                <Layout>
                    <Switch>
                        <Route path="/" exact component={Home} />
                        <Route path="/docs" component={Documentation} />
                        <Route path="/music" component={WIP} />
                        <Route path="/admin" component={WIP} />
                    </Switch>
                </Layout>
            </BrowserRouter>
        );
    }
}