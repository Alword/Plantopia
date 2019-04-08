import React, { Fragment } from 'react';
import { Router, Switch, Route, Redirect } from 'react-router-dom';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import history from '../history/history';
import ErrorAlertContainer from './ErrorAlertContainer';
import LoginPage from './LoginPage';
import RegisterPage from './RegisterPage';
import ProfilePage from './Profile/ProfilePage';
import PlantsPage from './Plants/PlantsPage';
import PlantInfoContainer from './Plants/PlantInfoContainer';
import RegularAppBar from '../components/AppBar/RegularAppBar';

function App({ userId }) {
    return (
        <Fragment>
            <ErrorAlertContainer />
            <Router history={history}>
                <Switch>
                    <RegularAppBar>
                        <Route exact path="/" render={() =>
                            !userId ?
                                <Redirect to="/login" /> :
                                <Redirect to="/my_plants" />} />
                        <Route path="/login" component={LoginPage} />
                        <Route path="/register" component={RegisterPage} />
                        <Route exact path="/my_plants" component={PlantsPage} />
                        <Route path="/my_plants/plant_info" component={PlantInfoContainer} />
                        <Route path="/store" component={null} />
                        <Route path="/profile/:id" component={ProfilePage} />
                    </RegularAppBar>
                </Switch>
            </Router>
        </Fragment>
    );
}

App.propTypes = {
    userId: PropTypes.number,
};

const mapStateToProps = store => {
    return {
        userId: store.access.userId
    };
};

export default connect(
    mapStateToProps
)(App);
