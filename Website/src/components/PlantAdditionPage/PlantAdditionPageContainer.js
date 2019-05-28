import React from 'react';
import PropTypes from 'prop-types';
import { AppBarContext } from '../TopAppBar/AppBarContext';
import UpwardButton from '../shared/UpwardButton';
import PlantAdditionPage from './PlantAdditionPage';

function PlantAdditionPageContainer() {
    const { resetAppBar } = React.useContext(AppBarContext);

    React.useEffect(() => {
        resetAppBar({
            title: 'Добавление растения',
            leftElement: <UpwardButton />
        });
    }, []);

    return  <PlantAdditionPage />;
}

PlantAdditionPageContainer.propTypes = {
    history: PropTypes.object.isRequired
};

export default PlantAdditionPageContainer;
