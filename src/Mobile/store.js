import { createStore, combineReducers } from 'redux';
import { createAction, handleActions } from 'redux-actions';

const appInitialState = {
  heartBeat: false,
};

const SET_HEART_BEAT = 'SET_HEART_BEAT';
export const setHeartBeat = createAction(SET_HEART_BEAT);

const App = handleActions(
  {
    [SET_HEART_BEAT]: (state, { payload }) => ({
      ...state,
      heartBeat: payload,
    }),
  },
  appInitialState,
);

const rootReducer = combineReducers({
  App,
});

const configureStore = () => createStore(rootReducer);
export const store = configureStore();
