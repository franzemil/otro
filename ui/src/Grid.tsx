import DataTable from 'react-data-table-component';

import React, { useState } from 'react';
const columns = [
    {
        name: 'Title',
        selector: (row: any) => row.title,
        sortable: true,
        sortField: 'title',
    },
    {
        name: 'Director',
        selector: (row: any) => row.director,
        sortable: true,
        sortField: 'director',
    },
    {
        name: 'Year',
        selector: (row: any) => row.year,
        sortable: true,
        sortField: 'year',
    },
];

const data = [
    {
        title: 'ABC',
        director: 'ABC',
        year: 100
    },
    {
        title: 'bb',
        director: 'ABC',
        year: 100
    }
]

export default function () {
    const [items, setData] = useState(data);

    const handleSort = async (column: any, sortDirection: any) => {
    /// reach out to some API and get new data using or sortField and sortDirection
    // e.g. https://api.github.com/search/repositories?q=blog&sort=${column.sortField}&order=${sortDirection}
        console.log(column, sortDirection);
        
      setData([...data, ...data]);
    };

    return (
        <DataTable
            columns={columns}
            data={items}
            onSort={handleSort}
            sortServer
        />
    );
}