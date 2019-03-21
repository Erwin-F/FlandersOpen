'use strict';
import React, { Fragment } from 'react';
import PropTypes from 'prop-types';

import { Icon, Table, TableHeader, TableHeaderCell, TableRow, TableBody, TableCell, Checkbox, TableFooter, Button } from "semantic-ui-react";

const EditableTable = (props) => {
    const {
        columns,
        keyField,
        data,
        onHeaderClick,
        OnCellClick,
        ColorCell,
        ColorRow,
        Editable
    } = props;

    function handleOnClickHeader(index) {
        // if (sortableColumns && sortableColumns.indexOf(index) >= 0) {
        //     return function (event) {
        //         onHeaderClick(index, event);
        //     };
        // }
        // else {
        //     return null;
        // }
    }

    function handleOnCellClick(event){
        if (!Editable) return;

        OnCellClick(event);
    }

    const headers = columns.map((column, i) => {
        return <TableHeaderCell key={i}>{column.text}</TableHeaderCell>;
    });

    const rows = data.map((dataRow, rowIndex) => {
        const color = dataRow["color"];
        let cellStyle = {};
        let rowStyle = {};

        if (typeof color !== "undefined"){
            if (ColorCell) cellStyle = { backgroundColor: "#" + color };
            if (ColorRow) rowStyle = { backgroundColor: "#" + color };
        }

        const key = dataRow[keyField];
        const cells = columns.map((column, colIndex) => {
            let cellText = dataRow[column.dataField];
            if(typeof cellText === "undefined") cellText = "";

            if (typeof cellText === "boolean") {
                return <TableCell style={cellStyle} verticalAlign={"middle"} collapsing key={colIndex}><Checkbox style={{ marginTop: "0px", marginBottom: "0px" }} collapsing readOnly id={key} checked={cellText} /></TableCell>;
            }

            return <TableCell style={cellStyle} verticalAlign={"middle"} key={colIndex}>{cellText.toString()}</TableCell>;
        });

        return <TableRow style={rowStyle} key={key}>{cells}</TableRow>;
    });

    // const footer = () => {
    //     return (
    //     <TableFooter>
    //         <TableRow>
    //             <TableHeaderCell>
    //                 <Button floated="left" icon labelPosition="left" primary size="small">
    //                     <Icon name="plus" /> Add Item
    //                 </Button>
    //             </TableHeaderCell>
    //         </TableRow>
    //     </TableFooter>);
    // };

    return (
        <Table celled>
            <TableHeader>
                <TableRow>
                    {headers}
                </TableRow>
            </TableHeader>
            <TableBody>
                {rows}
            </TableBody>
            
        </Table>
    );
};

EditableTable.defaultProps = {
    columns: [],
    keyField: "id",
    data: [],
    ColorCell: false,
    ColorRow: false,
    Editable: false
};

EditableTable.propTypes = {
    columns: PropTypes.array,
    keyField: PropTypes.string,
    data: PropTypes.array,
    onHeaderClick: PropTypes.func,
    OnCellClick: PropTypes.func,
    ColorCell: PropTypes.bool,
    ColorRow: PropTypes.bool,
    Editable: PropTypes.bool
};

export default EditableTable;