import React, { useState, useEffect } from 'react';
import TaskFilter from './TaskFilter';

const TaskList = () => {
    const [tasks, setTasks] = useState([]);
    const [filteredTasks, setFilteredTasks] = useState([]);

    useEffect(() => {
        fetch('/api/Task')
            .then(response => response.json())
            .then(data => {
                setTasks(data);
                setFilteredTasks(data); 
            })
            .catch(error => console.error('Error fetching tasks:', error));
    }, []);

    const filterTasks = (filterType) => {
        if (filterType === 'all') {
            setFilteredTasks(tasks);
        } else if (filterType === 'completed') {
            setFilteredTasks(tasks.filter(task => task.isCompleted === true));
        } else if (filterType === 'notCompleted') {
            setFilteredTasks(tasks.filter(task => task.isCompleted === false));
        }
    };

    return (
        <div>
            <TaskFilter onFilterChange={filterTasks} />
            <ul>
                {filteredTasks.map(task => (
                    <li key={task.id}>{task.name} - {task.isCompleted ? 'Completed' : 'Not Completed'}</li>
                ))}
            </ul>
        </div>
    );
};

export default TaskList;
