import React from 'react';
import PropTypes from 'prop-types';
import List from '@material-ui/core/List/index';
import NavListItem from './NavListItem';

function NavList({ authorized, onClick = null }) {
    return (
        <List onClick={onClick}>
            {!authorized ? (
                <>
                    <NavListItem to="/login" text="Вход" />
                    <NavListItem to="/register" text="Регистрация" />
                </>) : (
                <>
                    <NavListItem to="/my_plants" text="Мои растения" />
                    <NavListItem to="/store" text="Магазин" />
                </>)}
        </List>
    );
}

NavList.propTypes = {
    authorized: PropTypes.bool.isRequired,
    onClick: PropTypes.func,
};

export default NavList;
