import React, { Component } from "react";
import PropTypes from "prop-types";

class AutoBindComponent extends Component {
	constructor(props, context) {
		super();

		const handlerNames = this.getAllPropertyNames(this).filter(name => name.match(/^handleOn[A-Z]/));
		handlerNames.forEach(handlerName => this[handlerName] = this[handlerName].bind(this));
	}

	getAllPropertyNames(object) {
		const prototype = Object.getPrototypeOf(object);
		const ownPropertyNames = Object.getOwnPropertyNames(object);
		return prototype ? ownPropertyNames.concat(this.getAllPropertyNames(prototype)) : ownPropertyNames;
	}
}

export default AutoBindComponent;
