import React from 'react';
import PropTypes from 'prop-types';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import OpacityIcon from '@material-ui/icons/Opacity';

function PlantInfoCard({ handleRedirection }) {
    return (
        <Card>
            <CardContent>
                <Typography gutterBottom variant="h5">
                    Название цветка
                </Typography>
                <Typography>
                    <OpacityIcon fontSize="inherit" style={{color: '#3d5afe'}} />
                    50%
                </Typography>
            </CardContent>
            <CardActions>
                <Button
                    size="small"
                    color="primary"
                    onClick={handleRedirection(1)}
                >
                    Выбрать
                </Button>
            </CardActions>
        </Card>
    );
}

PlantInfoCard.propTypes = {
    handleRedirection: PropTypes.func.isRequired,
};

export default PlantInfoCard;
