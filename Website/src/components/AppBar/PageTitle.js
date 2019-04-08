import React from 'react';
import PropTypes from 'prop-types';
import { withRouter } from 'react-router-dom';
import { withStyles } from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography';

const styles = {
    grow: {
        flexGrow: 1,
    },
};

const guide = pathname => {
    switch (pathname) {
        case '/login':
            return 'Вход';
        case '/register':
            return 'Регистрация';
        case '/my_plants':
            return 'Мои растения';
        case '/store':
            return 'Магазин';
        default:
            if (pathname.startsWith('/profile')) {
                return 'Профиль';
            }
            return '';
    }
};

function PageTitle({ location, classes }) {
    return (
        <Typography noWrap variant="h6" color="inherit" className={classes.grow}>
            {guide(location.pathname)}
        </Typography>
    );
};

PageTitle.propTypes = {
    location: PropTypes.object.isRequired,
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(withRouter(PageTitle));
