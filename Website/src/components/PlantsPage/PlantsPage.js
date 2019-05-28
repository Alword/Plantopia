import React from 'react';
import Grid from '@material-ui/core/Grid';
import PlantInfoCard from './PlantInfoCard';
import ContentContainer from '../ContentContainer';
import PlantAddButton from './PlantAddButton';

function PlantsPage() {
    return (
        <ContentContainer>
            <Grid container spacing={24}>
                <Grid key={1} item xs={12} sm={6} md={4}>
                    <PlantInfoCard />
                </Grid>
                <PlantAddButton />
            </Grid>
        </ContentContainer >
    );
}

export default PlantsPage;
