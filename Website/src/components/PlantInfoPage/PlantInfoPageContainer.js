import React from 'react';
import PlantInfoPage from './PlantInfoPage';
import { AppBarContext } from '../TopAppBar/AppBarContext';
import UpwardButton from '../shared/UpwardButton';

function PlantInfoPageContainer() {
    const { resetAppBar } = React.useContext(AppBarContext);

    React.useEffect(() => {
        resetAppBar({
            title: 'Информация о растении',
            leftElement: <UpwardButton />
        });
    }, []);

    return (
        <PlantInfoPage />
    );
}

export default PlantInfoPageContainer;
