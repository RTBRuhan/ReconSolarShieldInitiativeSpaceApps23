<!-- src/routes/home.svelte -->

<script>
    import { Link } from "svelte-routing";
    import S_Sat from "./s_sat.svelte";
    import Dis_Sat from "./dis_sat.svelte";
    import { onMount } from "svelte";
    import { Chart } from "chart.js/auto";

    let displaySSatellite = false;
    let displayDSCOVRSatellite = false;

    function showSSatellite() {
        displaySSatellite = true;
        displayDSCOVRSatellite = false;
    }

    function showDSCOVRSatellite() {
        displaySSatellite = false;
        displayDSCOVRSatellite = true;
    }

    // Generate dummy data for Earth and Sun variables
    const earthData = {
        Time: "2023-10-06T05:26:29.56203752z",
        Latitude: 86.5,
        Longitude: 164.04,
        Altitude: 0,
        Intensity: 57427.5,
        Declination: -83.5,
        Inclination: 89.7,
        North: 29.8,
        East: -262.8,
        Vertical: 57426.9,
        Horizontal: 26,
    };

    const sunData = {
        Temperature: 3700, // 3.7×10^3 °C
        Speed: 30000, // 30,000 m/s
        ProtonDensity: 3700, // 3.7×10^3
        ApproxPressure: 2.5e11, // 2.5 x 10^11
        bx_gsm: 4.2,
        by_gsm: -3.14,
        bz_gsm: 3.09,
        bt: 6.08,
    };

    // Convert the Earth and Sun data objects into arrays for chart data
    const earthLabels = Object.keys(earthData);
    const earthValues = Object.values(earthData);

    const sunLabels = Object.keys(sunData);
    const sunValues = Object.values(sunData);

    // Chart data for Earth and Sun
    const earthChartData = {
        labels: earthLabels,
        datasets: [
            {
                label: "Earth Data",
                data: earthValues,
                borderColor: "rgba(75, 192, 192, 1)",
                borderWidth: 2,
                fill: false,
            },
        ],
    };

    const sunChartData = {
        labels: sunLabels,
        datasets: [
            {
                label: "Sun Data",
                data: sunValues,
                borderColor: "rgba(255, 206, 86, 1)",
                borderWidth: 2,
                fill: false,
            },
        ],
    };

    let earthChart;
    let sunChart;

    // Function to check for magnetic reconnection
    function checkMagneticReconnection() {
        const earthVertical = earthData.Vertical;
        const sunBzGsm = sunData.bz_gsm;

        if (earthVertical === sunBzGsm) {
            return true;
        } else {
            return false;
        }
    }

    let magneticReconnection = false;

    onMount(() => {
        // Initialize the Earth chart after the component is mounted
        const earthCanvas = document.getElementById("earthChart");
        earthChart = new Chart(earthCanvas, {
            type: "line",
            data: earthChartData,
            options: {
                scales: {
                    y: {
                        beginAtZero: true,
                    },
                },
                plugins: {
                    title: {
                        display: true,
                        text: "Earth Data",
                    },
                    legend: {
                        display: false,
                    },
                },
            },
        });

        // Initialize the Sun chart after the component is mounted
        const sunCanvas = document.getElementById("sunChart");
        sunChart = new Chart(sunCanvas, {
            type: "line",
            data: sunChartData,
            options: {
                scales: {
                    y: {
                        beginAtZero: true,
                    },
                },
                plugins: {
                    title: {
                        display: true,
                        text: "Sun Data",
                    },
                    legend: {
                        display: false,
                    },
                },
            },
        });

        // Check for magnetic reconnection
        magneticReconnection = checkMagneticReconnection();
    });
</script>

<main class="home-container">
    <div class="navbar">
        <div class="navbar-buttons">
            <button on:click={showSSatellite}> ACE-Satellite </button>
            <button on:click={showDSCOVRSatellite}> DSCOVR Satellite </button>
        </div>
    </div>

    <!-- Display the S-Satellite component when clicked -->
    {#if displaySSatellite}
        <S_Sat />
    {:else}
        <!-- Display the DSCOVR Satellite component when clicked -->
        {#if displayDSCOVRSatellite}
            <Dis_Sat />
        {/if}
    {/if}

    <!-- Earth and Sun Data Line Charts -->
    <section class="data-graphs">
        <div class="data-graph">
            <h2>Earth Data</h2>
            <canvas id="earthChart" width="400" height="200"></canvas>
        </div>
        <div class="data-graph">
            <h2>Sun Data</h2>
            <canvas id="sunChart" width="400" height="200"></canvas>
        </div>
    </section>
    
    <!-- Magnetic Reconnection Detection -->
    {#if magneticReconnection}
        <p>Magnetic Reconnection Detected!</p>
    {:else}
        <p>No Magnetic Reconnection Detected.</p>
    {/if}
</main>

<style>
    /* Your CSS styles for home.svelte */
    .navbar {
        display: flex;
        justify-content: space-between;
        align-items: center;
        margin-top: 40px;
    }

    .navbar-buttons {
        display: flex;
        gap: 20px;
    }

    .navbar-buttons button {
        background: none;
        border: 2px solid #ffcc00;
        font-size: 24px;
        color: #ffcc00;
        cursor: pointer;
        display: flex; /* Align icon and text horizontally */
        align-items: center; /* Center icon and text vertically */
        padding: 4px 8px; /* Adjust padding for smaller button size */
        font-size: 1rem; /* Set font size to match h4 */
        border-radius: 10px;
    }

    .data-graphs {
        display: flex;
        justify-content: space-between;
        margin-top: 40px;
    }

    .data-graph {
        border: 1px solid #ddd;
        text-align: center;
        padding: 20px;
        width: 48%; /* Adjust the width as needed */
        box-sizing: border-box;
    }
</style>
