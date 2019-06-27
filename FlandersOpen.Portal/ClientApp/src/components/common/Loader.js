'use strict';
import React, { Fragment } from 'react';
import PropTypes from 'prop-types';

const Loader = (props)  => {
    return (
        <div className="text-center">
            <div className="spinner-border" role="status">
                <span className="sr-only">Loading...</span>
            </div>
        </div>);
};

Loader.propTypes = {
};

export default Loader;