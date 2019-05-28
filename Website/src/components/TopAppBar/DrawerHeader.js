import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles/index';
import Link from '@material-ui/core/Link/index';

const styles = theme => ({
    drawerHeader: {
        display: 'flex',
        alignItems: 'center',
        padding: `0 ${theme.spacing.unit * 3}px`,
        ...theme.mixins.toolbar,
    },
});

function DrawerHeader({ classes }) {
    return (
        <div className={classes.drawerHeader}>
            <Link href='https://plantopia.ru' variant="h6">
                Plantopia
            </Link>
        </div>
    );
}

DrawerHeader.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(DrawerHeader);
