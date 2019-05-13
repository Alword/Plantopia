import { createMuiTheme } from '@material-ui/core/styles';
import teal from '@material-ui/core/colors/teal';
import orange from '@material-ui/core/colors/orange';

const theme = createMuiTheme({
    palette: {
        primary: teal,
        secondary: orange,
    },
    typography: {
        useNextVariants: true,
    },
});

export default theme;
