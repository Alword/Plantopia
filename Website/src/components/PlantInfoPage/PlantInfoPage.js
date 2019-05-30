import React from 'react';
import PropTypes from 'prop-types';
import withStyles from '@material-ui/core/styles/withStyles';
import Typography from '@material-ui/core/Typography';
import ResponsiveContainer from 'recharts/lib/component/ResponsiveContainer';
import AreaChart from 'recharts/lib/chart/AreaChart';
import Area from 'recharts/lib/cartesian/Area';
import XAxis from 'recharts/lib/cartesian/XAxis';
import YAxis from 'recharts/lib/cartesian/YAxis';
import CartesianGrid from 'recharts/lib/cartesian/CartesianGrid';
import Tooltip from 'recharts/lib/component/Tooltip';
import ContentContainer from '../ContentContainer';

const styles = {
    chartContainer: {
        marginLeft: -22,
    },
};

function PlantInfoPage({ plantSensorReadings, classes }) {
    return (
        <ContentContainer>
            <Typography gutterBottom variant="h4">
                Кактус
            </Typography>
            <Typography component="div" className={classes.chartContainer}>
                <ResponsiveContainer width="99%" height={320}>
                    <AreaChart data={plantSensorReadings}>
                        <XAxis dataKey="datetime" />
                        <YAxis />
                        <CartesianGrid vertical={false} strokeDasharray="3 3" />
                        <Tooltip />
                        <Area name="Температура" type="monotone" dataKey="temperature" />
                    </AreaChart>
                </ResponsiveContainer>
            </Typography>
        </ContentContainer>
    );
}

PlantInfoPage.propTypes = {
    classes: PropTypes.object.isRequired,
    plantSensorReadings: PropTypes.arrayOf(
        PropTypes.shape({
            datetime: PropTypes.string.isRequired,
            temperature: PropTypes.number.isRequired
        })
    ).isRequired
};

export default withStyles(styles)(PlantInfoPage);
