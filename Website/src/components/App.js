import React from 'react';
import PropTypes from 'prop-types';
import { Redirect, Route, Router, Switch } from 'react-router-dom';
import { connect } from 'react-redux';
import history from '../history';
import TopAppBar from './TopAppBar';
import ErrorSnackbar from './ErrorSnackbar';
import LoginPage from './LoginPage';
import RegisterPage from './RegisterPage';
import PlantsPage from './PlantsPage';
import PlantInfoPage from './PlantInfoPage';
import PlantAdditionPage from './PlantAdditionPage';
import StorePage from './StorePage';
import ProfilePage from './ProfilePage';
import ProfileSettingsPage from './ProfileSettingsPage';

function App({ userId }) {
    return (
        <>
            <ErrorSnackbar />
            <Router history={history}>
                <Switch>
                    <TopAppBar>
                        <Route exact path="/" render={() =>
                            !userId ?
                                <Redirect to="/login" /> :
                                <Redirect to="/my_plants" />} />
                        <Route path="/login" component={LoginPage} />
                        <Route path="/register" component={RegisterPage} />
                        <Route path="/my_plants" component={PlantsPage} />
                        <Route path="/plant_addition" component={PlantAdditionPage} />
                        <Route path="/store" component={StorePage} />
                        <Route exact path="/plant_info" component={PlantInfoPage} />
                        <Route exact path="/profile" render={() => <Redirect to={`/profile/${userId}`} />} />
                        <Route path="/profile/:userId" component={ProfilePage} />
                        <Route path="/profile_settings" component={ProfileSettingsPage} />
                    </TopAppBar>
                </Switch>
            </Router>
        </>
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
