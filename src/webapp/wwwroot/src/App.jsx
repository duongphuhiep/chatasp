import React, { Component } from 'react';
import { observer } from 'mobx-react';
import DevTools from 'mobx-react-devtools';

@observer
class App extends Component {
	render() {
		return (
			<div>
				<h1>Reactivity from mobx</h1>
				<button onClick={this.onReset}>
					Seconds passed: {this.props.appState.timer}
				</button>
				<DevTools/>
			</div>
		);
	}

	onReset = () => {
		this.props.appState.resetTimer();
	}
};

export default App;
