'use strict';
import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import { Table } from 'reactstrap';

const EditableTable = (props)  => {
    const {
        columns, 
        keyField, 
        items, 
        ColorCell, 
        ColorRow, 
        textSize
    } = props;

    const headers = columns.map((column, i) => {
        return <th key={i}>{column.text}</th>;
    });

    const rows = items.map((item, rowIndex) => {
        const color = item["color"];
        let cellStyle = {};
        let rowStyle = {};

        if (typeof textSize !== "undefined") {
            cellStyle.fontSize = textSize + "px";
        }

        if (typeof color !== "undefined"){
            if (ColorCell) cellStyle.backgroundColor = "#" + color;
            if (ColorRow) rowStyle.backgroundColor = "#" + color;
        }

        const key = item[keyField];
        const cells = columns.map((column, colIndex) => {
            let cellText = item[column.dataField];
            if(typeof cellText === "undefined") cellText = "";

            if (typeof cellText === "boolean") {
                return <td style={cellStyle}></td>; //verticalAlign={"middle"} collapsing key={colIndex}><Checkbox style={{ marginTop: "0px", marginBottom: "0px" }} collapsing readOnly id={key} checked={cellText} /></TableCell>;
            }

            return <td style={cellStyle} key={colIndex}>{cellText.toString()}</td>;
        });

        return <tr style={rowStyle} key={key}>{cells}</tr>;
    });

    return (
    <Table size="sm" bordered>
        <thead><tr>{headers}</tr></thead>
        <tbody>{rows}</tbody>
    </Table>);
};

EditableTable.defaultProps = {
    columns: [],
    keyField: "id",
    items: [], 
    ColorCell: false,
    ColorRow: false
};

EditableTable.propTypes = {
    columns: PropTypes.array,
    keyField: PropTypes.string,
    items: PropTypes.array,
    ColorCell: PropTypes.bool,
    ColorRow: PropTypes.bool,
    textSize: PropTypes.number
};

export default EditableTable;