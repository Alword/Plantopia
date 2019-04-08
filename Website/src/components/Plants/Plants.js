import React from 'react';
import PropTypes from 'prop-types';
import withStyles from '@material-ui/core/styles/withStyles';
import Grid from '@material-ui/core/Grid';
import { drawerWidth } from '../AppBar/RegularAppBar';
import PlantInfoCard from './PlantInfoCard';

const styles = theme => ({
    root: {
        [theme.breakpoints.up(1100 + drawerWidth + theme.spacing.unit * 3 * 2)]: {
            width: 1100,
            marginLeft: 'auto',
            marginRight: 'auto',
        },
    },
});

function Plants({ handleRedirection, classes }) {
    return (
        <div className={classes.root}>
            <Grid container spacing={24}>
                <Grid key={1} item xs={12} sm={6} md={4}>
                    <PlantInfoCard
                        handleRedirection={handleRedirection}
                    />
                </Grid>
            </Grid>
        </div >
    );
}

Plants.propTypes = {
    handleRedirection: PropTypes.func.isRequired,
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Plants);
