import React from 'react'

const WeekPlans = ({ weekPlans }) => {
  return (
    <div>
      <center><h1>Week Plans</h1></center>
      {weekPlans.map((weekPlan) => (
        <div className="card" key={weekPlan.id}>
          <div className="card-body">
            <h5 className="card-title">{weekPlan.title}</h5>
            <h6 className="card-subtitle mb-2 text-muted">{(new Date(weekPlan.startDate)).toISOString().split('T')[0]}</h6>
            <p className="card-text">{weekPlan.goals}</p>
            <p className="card-text">{weekPlan.tasks}</p>
          </div>
        </div>
      ))}
    </div>
  )
};

export default WeekPlans

