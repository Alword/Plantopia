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

const data1 = [
    { name: '1:00', humidity: 20 },
    { name: '2:00', humidity: 30 },
    { name: '3:00', humidity: 40 },
    { name: '4:00', humidity: 30 },
    { name: '5:00', humidity: 20 },
    { name: '6:00', humidity: 40 },
    { name: '7:00', humidity: 60 },
    { name: '8:00', humidity: 20 },
    { name: '9:00', humidity: 30 },
    { name: '10:00', humidity: 40 },
    { name: '11:00', humidity: 30 },
    { name: '12:00', humidity: 20 },
    { name: '13:00', humidity: 40 },
    { name: '14:00', humidity: 60 },
    { name: '15:00', humidity: 20 },
    { name: '16:00', humidity: 30 },
    { name: '17:00', humidity: 40 },
    { name: '18:00', humidity: 30 },
    { name: '19:00', humidity: 20 },
    { name: '20:00', humidity: 40 },
    { name: '21:00', humidity: 60 },
    { name: '22:00', humidity: 30 },
    { name: '23:00', humidity: 20 },
    { name: '24:00', humidity: 40 },
];

const data2 = [
    { name: 'Пн', humidity: 20 },
    { name: 'Вт', humidity: 30 },
    { name: 'Ср', humidity: 40 },
    { name: 'Чт', humidity: 30 },
    { name: 'Пт', humidity: 20 },
    { name: 'Сб', humidity: 40 },
    { name: 'Вс', humidity: 100 },
];

const data3 = [
    { name: '01', humidity: 20 },
    { name: '02', humidity: 30 },
    { name: '03', humidity: 40 },
    { name: '04', humidity: 30 },
    { name: '05', humidity: 20 },
    { name: '06', humidity: 40 },
    { name: '07', humidity: 60 },
    { name: '08', humidity: 20 },
    { name: '09', humidity: 30 },
    { name: '10', humidity: 40 },
    { name: '11', humidity: 30 },
    { name: '12', humidity: 20 },
    { name: '13', humidity: 40 },
    { name: '14', humidity: 60 },
    { name: '15', humidity: 20 },
    { name: '16', humidity: 30 },
    { name: '17', humidity: 40 },
    { name: '18', humidity: 30 },
    { name: '19', humidity: 20 },
    { name: '20', humidity: 40 },
    { name: '21', humidity: 60 },
    { name: '22', humidity: 30 },
    { name: '23', humidity: 20 },
    { name: '24', humidity: 40 },
    { name: '25', humidity: 30 },
    { name: '26', humidity: 20 },
    { name: '27', humidity: 40 },
    { name: '28', humidity: 30 },
    { name: '29', humidity: 20 },
    { name: '30', humidity: 40 },
    { name: '31', humidity: 40 },
];

function PlantInfoPage({ classes }) {
    return (
        <ContentContainer>
            <Typography gutterBottom variant="h4">
                Кактус
            </Typography>
            <Typography component="div" className={classes.chartContainer}>
                <ResponsiveContainer  width="99%" height={320}>
                    <AreaChart data={data1}>
                        <XAxis dataKey="name" />
                        <YAxis />
                        <CartesianGrid vertical={false} strokeDasharray="3 3" />
                        <Tooltip />
                        <Area name="Влажность в процентах" type="monotone" dataKey="humidity" />
                    </AreaChart>
                </ResponsiveContainer>
            </Typography>
            <Typography component="div" className={classes.chartContainer}>
                <ResponsiveContainer  width="99%" height={320}>
                    <AreaChart data={data2}>
                        <XAxis dataKey="name" />
                        <YAxis />
                        <CartesianGrid vertical={false} strokeDasharray="3 3" />
                        <Tooltip />
                        <Area name="Влажность в процентах" type="monotone" dataKey="humidity" />
                    </AreaChart>
                </ResponsiveContainer>
            </Typography>
            <div className={classes.chartContainer}>
                <ResponsiveContainer  width="99%" height={320}>
                    <AreaChart data={data3}>
                        <XAxis dataKey="name" />
                        <YAxis />
                        <CartesianGrid vertical={false} strokeDasharray="3 3" />
                        <Tooltip />
                        <Area name="Влажность в процентах" type="monotone" dataKey="humidity" />
                    </AreaChart>
                </ResponsiveContainer>
            </div>
        </ContentContainer>
    );
}

PlantInfoPage.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(PlantInfoPage);
