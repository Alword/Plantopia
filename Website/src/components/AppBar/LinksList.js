import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import List from '@material-ui/core/List';
import LinksListItem from './LinksListItem';

function LinksList({ authorized, onClick }) {
    return (
        <List onClick={onClick}>
            {!authorized ?
                <Fragment>
                    <LinksListItem to="/login" text="Вход" />
                    <LinksListItem to="/register" text="Регистрация" />
                </Fragment> :
                <Fragment>
                    <LinksListItem to="/my_plants" text="Мои растения" />
                    <LinksListItem to="/store" text="Магазин" />
                </Fragment>}
        </List>
    );
};

LinksList.propTypes = {
    authorized: PropTypes.bool.isRequired,
    onClick: PropTypes.func.isRequired,
};

export default LinksList;
