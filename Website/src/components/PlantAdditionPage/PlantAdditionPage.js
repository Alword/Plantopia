import React from 'react';
import PropTypes from 'prop-types';
import withStyles from '@material-ui/core/styles/withStyles';
import Paper from '@material-ui/core/Paper';
import TextField from '@material-ui/core/TextField';
import MenuItem from '@material-ui/core/MenuItem';
import InputAdornment from '@material-ui/core/InputAdornment';
import Button from '@material-ui/core/Button';
import ContentContainer from '../ContentContainer';

const styles = theme => ({
    paper: {
        marginTop: theme.spacing.unit * 2,
        padding: `${theme.spacing.unit * 2}px ${theme.spacing.unit * 3}px ${theme.spacing.unit * 3}px`,
    },
    actions: {
        display: 'flex',
        justifyContent: 'flex-end',
    },
    submit: {
        marginTop: theme.spacing.unit * 3,
    },
});

const ranges = [
    {
        value: '0-20',
        label: '0-20',
    },
    {
        value: '21-40',
        label: '21-40',
    },
    {
        value: '41-60',
        label: '41-60',
    },
    {
        value: '61-80',
        label: '61-80',
    },
    {
        value: '81-100',
        label: '81-100',
    },
];

function PlantAdditionPage({ classes }) {
    const [values, setValues] = React.useState({
        humidity: '',
    });

    const handleChange = prop => event => {
        setValues({ ...values, [prop]: event.target.value });
    };

    return (
        <ContentContainer size="sm">
            <Paper className={classes.paper}>
                <form>
                    <TextField
                        autoFocus
                        id="plantTitle"
                        label="Название растения"
                        fullWidth
                        margin="normal"
                        variant="outlined"
                    />
                    <TextField
                        select
                        margin="normal"
                        variant="outlined"
                        label="Минимально необходимый уровень влажности"
                        fullWidth
                        value={values.humidity}
                        onChange={handleChange('humidity')}
                        InputProps={{
                            startAdornment: <InputAdornment position="start">%</InputAdornment>,
                        }}
                    >
                        {ranges.map(option => (
                            <MenuItem key={option.value} value={option.value}>
                                {option.label}
                            </MenuItem>
                        ))}
                    </TextField>
                    <TextField
                        id="deviceId"
                        label="Идентификатор оборудования"
                        fullWidth
                        margin="normal"
                        variant="outlined"
                    />
                    <div className={classes.actions}>
                        <Button
                            type="submit"
                            variant="contained"
                            color="primary"
                            className={classes.submit}
                        >
                            Добавить
                        </Button>
                    </div>
                </form>
            </Paper>
        </ContentContainer>
    );
}

PlantAdditionPage.propTypes = {
    classes: PropTypes.object.isRequired
};

export default withStyles(styles)(PlantAdditionPage);
