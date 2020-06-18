import React from 'react'

const WeekPlans = ({ weekPlans }) => {
  return (
    <div>
      <center><h1>Week Plans</h1></center>
      {weekPlans.map((weekPlan) => (
        <div class="card">
          <div class="card-body">
            <h5 class="card-title">{weekPlan.title}</h5>
            <h6 class="card-subtitle mb-2 text-muted">{(new Date(weekPlan.startDate)).toISOString().split('T')[0]}</h6>
            <p class="card-text">{weekPlan.goals}</p>
            <p class="card-text">{weekPlan.tasks}</p>
          </div>
        </div>
      ))}
    </div>
  )
};

export default WeekPlans

