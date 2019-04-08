

import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { MuiThemeProvider, createMuiTheme } from '@material-ui/core/styles';
import CssBaseline from '@material-ui/core/CssBaseline';
import teal from '@material-ui/core/colors/teal';
import orange from '@material-ui/core/colors/orange';
import pink from '@material-ui/core/colors/pink';
import store from './store/configureStore';
import App from './containers/App';

const theme = createMuiTheme({
    palette: {
        primary: teal,
        secondary: orange,
        error: pink,
    },
    typography: {
        useNextVariants: true,
    },
});

ReactDOM.render(
    <MuiThemeProvider theme={theme}>
        <Provider store={store}>
            <CssBaseline />
            <App />
        </Provider>
    </MuiThemeProvider>,
    document.getElementById('root')
);
