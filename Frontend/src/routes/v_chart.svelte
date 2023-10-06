<script>
  import { onMount } from 'svelte';
  import Chart from 'chart.js/auto';

  let temperatureChart;
  let magnetometerChart;
  let positionChart;
  let orientationChart;

  onMount(() => {
    const temperatureCtx = temperatureChart.getContext('2d');
    const magnetometerCtx = magnetometerChart.getContext('2d');
    const positionCtx = positionChart.getContext('2d');
    const orientationCtx = orientationChart.getContext('2d');

    // Data for the temperature chart
    const temperatureData = {
      labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May'],
      datasets: [
        {
          label: 'Sun',
          data: [100, 110, 120, 130, 140],
          borderColor: 'rgba(255, 99, 132, 1)',
          borderWidth: 2,
          fill: false,
        },
        {
          label: 'Earth',
          data: [10, 15, 20, 25, 30],
          borderColor: 'rgba(54, 162, 235, 1)',
          borderWidth: 2,
          fill: false,
        },
      ],
    };

    // Data for the magnetometer chart
    const magnetometerData = {
      labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May'],
      datasets: [
        {
          label: 'Bt',
          data: [50, 55, 60, 65, 70],
          borderColor: 'rgba(255, 0, 0, 1)',
          borderWidth: 2,
          fill: false,
        },
        {
          label: 'ByGSM',
          data: [20, 25, 30, 35, 40],
          borderColor: 'rgba(0, 255, 0, 1)',
          borderWidth: 2,
          fill: false,
        },
        {
          label: 'BxGSM',
          data: [70, 75, 80, 85, 90],
          borderColor: 'rgba(0, 0, 255, 1)',
          borderWidth: 2,
          fill: false,
        },
        {
          label: 'BzGSM',
          data: [30, 35, 40, 45, 50],
          borderColor: 'rgba(255, 255, 0, 1)',
          borderWidth: 2,
          fill: false,
        },
      ],
    };

    // Data for the position chart (latitude, longitude, altitude)
    const positionData = {
      labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May'],
      datasets: [
        {
          label: 'Latitude',
          data: [40, 41, 42, 43, 44],
          borderColor: 'rgba(255, 99, 132, 1)',
          borderWidth: 2,
          fill: false,
        },
        {
          label: 'Longitude',
          data: [-73, -74, -75, -76, -77],
          borderColor: 'rgba(54, 162, 235, 1)',
          borderWidth: 2,
          fill: false,
        },
        {
          label: 'Altitude',
          data: [100, 110, 120, 130, 140],
          borderColor: 'rgba(255, 0, 0, 1)',
          borderWidth: 2,
          fill: false,
        },
      ],
    };

    // Data for the orientation chart (intensity, inclination, declination, north, east, vertical, horizontal)
    const orientationData = {
      labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May'],
      datasets: [
        {
          label: 'Intensity',
          data: [100, 110, 120, 130, 140],
          borderColor: 'rgba(255, 99, 132, 1)',
          borderWidth: 2,
          fill: false,
        },
        {
          label: 'Inclination',
          data: [10, 15, 20, 25, 30],
          borderColor: 'rgba(54, 162, 235, 1)',
          borderWidth: 2,
          fill: false,
        },
        {
          label: 'Declination',
          data: [-10, -15, -20, -25, -30],
          borderColor: 'rgba(255, 0, 0, 1)',
          borderWidth: 2,
          fill: false,
        },
        {
          label: 'North',
          data: [50, 55, 60, 65, 70],
          borderColor: 'rgba(0, 255, 0, 1)',
          borderWidth: 2,
          fill: false,
        },
        {
          label: 'East',
          data: [-20, -25, -30, -35, -40],
          borderColor: 'rgba(0, 0, 255, 1)',
          borderWidth: 2,
          fill: false,
        },
        {
          label: 'Vertical',
          data: [-30, -35, -40, -45, -50],
          borderColor: 'rgba(255, 255, 0, 1)',
          borderWidth: 2,
          fill: false,
        },
        {
          label: 'Horizontal',
          data: [70, 75, 80, 85, 90],
          borderColor: 'rgba(128, 128, 128, 1)',
          borderWidth: 2,
          fill: false,
        },
      ],
    };

    // Adjust the chart height for larger charts
    const chartHeight = 600; // Set the desired height here

    const commonOptions = {
      maintainAspectRatio: true, // Enable aspect ratio
    };

    const temperatureConfig = {
      type: 'line',
      data: temperatureData,
      options: {
        ...commonOptions,
        scales: {
          y: {
            beginAtZero: true,
            title: {
              display: true,
              text: 'Temperature (°C)',
            },
          },
          x: {
            title: {
              display: true,
              text: 'Month',
            },
          },
        },
      },
    };

    const magnetometerConfig = {
      type: 'line',
      data: magnetometerData,
      options: {
        ...commonOptions,
        scales: {
          y: {
            beginAtZero: true,
            title: {
              display: true,
              text: 'Magnetometer Data',
            },
          },
          x: {
            title: {
              display: true,
              text: 'Month',
            },
          },
        },
      },
    };

    const positionConfig = {
      type: 'line',
      data: positionData,
      options: {
        ...commonOptions,
        scales: {
          y: {
            beginAtZero: true,
            title: {
              display: true,
              text: 'Position Data',
            },
          },
          x: {
            title: {
              display: true,
              text: 'Month',
            },
          },
        },
      },
    };

    const orientationConfig = {
      type: 'line',
      data: orientationData,
      options: {
        ...commonOptions,
        scales: {
          y: {
            beginAtZero: true,
            title: {
              display: true,
              text: 'Orientation Data',
            },
          },
          x: {
            title: {
              display: true,
              text: 'Month',
            },
          },
        },
      },
    };

    const resizeCharts = () => {
      temperatureChart.height = chartHeight;
      magnetometerChart.height = chartHeight;
      positionChart.height = chartHeight;
      orientationChart.height = chartHeight;
    };

    new Chart(temperatureCtx, temperatureConfig);
    new Chart(magnetometerCtx, magnetometerConfig);
    new Chart(positionCtx, positionConfig);
    new Chart(orientationCtx, orientationConfig);

    // Resize charts initially
    resizeCharts();
  });
</script>

<style>
  .chart-container {
    display: grid;
    grid-template-columns: repeat(2, 1fr);
    gap: 20px;
  }

  .chart-items {
    width: 100%;
  }
</style>

<div class="chart-container">
  <div class="chart-items">
    <canvas bind:this={temperatureChart} id="temperatureChart"></canvas>
  </div>
  <div class="chart-items">
    <canvas bind:this={magnetometerChart} id="magnetometerChart"></canvas>
  </div>
  <div class="chart-items">
    <canvas bind:this={positionChart} id="positionChart"></canvas>
  </div>
  <div class="chart-items">
    <canvas bind:this={orientationChart} id="orientationChart"></canvas>
  </div>
</div>
