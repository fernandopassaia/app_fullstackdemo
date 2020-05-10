import { createAppContainer, createSwitchNavigator } from 'react-navigation';
import Login from './pages/Login';
import Dashboard from './pages/Dashboard';
import SaveDevice from './pages/SaveDevice'

const Routes = createAppContainer(
    createSwitchNavigator({
        Login,
        Dashboard,
        SaveDevice
    })
);

export default Routes;