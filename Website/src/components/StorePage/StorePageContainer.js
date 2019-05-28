import React from 'react';
import { AppBarContext } from '../TopAppBar/AppBarContext';

function StorePageContainer() {
    const { resetAppBar } = React.useContext(AppBarContext);

    React.useEffect(() => {
        resetAppBar({
            title: 'Магазин'
        });
    }, []);

    return (
        null
    );
}

export default StorePageContainer;
