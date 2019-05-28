import React from 'react';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import OpacityIcon from '@material-ui/icons/Opacity';

function PlantInfoCard() {
    return (
        <Card>
            <CardContent>
                <Typography gutterBottom variant="h5">
                    Кактус
                </Typography>
                <Typography>
                    <OpacityIcon fontSize="inherit" style={{color: '#3d5afe'}} />
                    50%
                </Typography>
                <Typography color="secondary">
                    Требуется полив!
                </Typography>
            </CardContent>
            <CardActions>
                <Button
                    size="small"
                    color="primary"
                    href="/#plant_info"
                >
                    Выбрать
                </Button>
            </CardActions>
        </Card>
    );
}

export default PlantInfoCard;
