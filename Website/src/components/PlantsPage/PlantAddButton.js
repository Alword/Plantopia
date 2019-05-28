import React from 'react';
import PropTypes from 'prop-types';
import withStyles from '@material-ui/core/styles/withStyles';
import Fab from '@material-ui/core/Fab/index';
import AddIcon from '@material-ui/icons/Add';

const styles = theme => ({
    button: {
        margin: theme.spacing.unit,
    },
    fab: {
        position: 'fixed',
        bottom: theme.spacing.unit * 2,
        right: theme.spacing.unit * 2,
    },
});

function PlantAddButton({ classes }) {
    return (
        <Fab
            className={classes.fab}
            color="primary"
            href="/#plant_addition"
        >
            <AddIcon />
        </Fab>
    );
}

PlantAddButton.propTypes = {
    classes: PropTypes.object.isRequired
};

export default withStyles(styles)(PlantAddButton);
