<!-- src/routes/dis_sat.svelte -->

<main class="dis-sat-container">
    <!-- Left Floating Items -->

    <div style=" font-size:18px" class="left-float">
        <h4>Sun Data</h4>
        <div class="status-icon">
            <span class="square" />
            <span class="status-label">Temperature:</span>
            <span class="status-text">
                <span class="temperature-value">3.7×10³</span> °C
            </span>
        </div>

        <div class="status-icon">
            <span class="square" />
            <span class="status-label">Speed:</span>
            <span class="status-text">
                <span class="speed-value">30,000</span> m/s
            </span>
        </div>

        <div class="status-icon">
            <span class="square" />
            <span class="status-label">Proton Density:</span>
            <span class="status-text">
                <span class="proton-density-value">3.7×10³</span>
            </span>
        </div>

        <div class="status-icon">
            <span class="square" />
            <span class="status-label">Approx. Dynamic Pressure:</span>
            <span class="status-text">
                <span class="dynamic-pressure-value">2.5 x 10^11</span>
            </span>
        </div>

        <div class="status-icon">
            <span class="square" />
            <span class="status-label">bx_gsm:</span>
            <span class="status-text">
                <span class="bx-gsm-value">4.2</span>
            </span>
        </div>

        <div class="status-icon">
            <span class="square" />
            <span class="status-label">by_gsm:</span>
            <span class="status-text">
                <span class="by-gsm-value">3.4</span>
            </span>
        </div>

        <div class="status-icon">
            <span class="square" />
            <span class="status-label">bz_gsm:</span>
            <span class="status-text">
                <span class="bz-gsm-value">3.09</span>
            </span>
        </div>

        <div class="status-icon">
            <span class="square" />
            <span class="status-label">bt:</span>
            <span class="status-text">
                <span class="bt-value">6.08</span>
            </span>
        </div>
        <h4>Earth Data</h4>
        <div class="left-float">
            <div class="status-icon">
                <span class="square" />
                <span class="status-label">Time:</span>
                <span class="status-text">2023-10-06T05:26:29.56203752Z</span>
            </div>
            <div class="status-icon">
                <span class="square" />
                <span class="status-label">Latitude:</span>
                <span class="status-text">86.5</span>
            </div>
            <div class="status-icon">
                <span class="square" />
                <span class="status-label">Longitude:</span>
                <span class="status-text">164.04</span>
            </div>
            <div class="status-icon">
                <span class="square" />
                <span class="status-label">Altitude:</span>
                <span class="status-text">0</span>
            </div>
            <div class="status-icon">
                <span class="square" />
                <span class="status-label">Intensity:</span>
                <span class="status-text">57427.5</span>
            </div>
            <div class="status-icon">
                <span class="square" />
                <span class="status-label">Declination:</span>
                <span class="status-text">-83.5</span>
            </div>
            <div class="status-icon">
                <span class="square" />
                <span class="status-label">Inclination:</span>
                <span class="status-text">89.7</span>
            </div>
            <div class="status-icon">
                <span class="square" />
                <span class="status-label">North:</span>
                <span class="status-text">29.8</span>
            </div>
            <div class="status-icon">
                <span class="square" />
                <span class="status-label">East:</span>
                <span class="status-text">-262.8</span>
            </div>
            <div class="status-icon">
                <span class="square" />
                <span class="status-label">Vertical:</span>
                <span class="status-text">57426.9</span>
            </div>
            <div class="status-icon">
                <span class="square" />
                <span class="status-label">Horizontal:</span>
                <span class="status-text">264.5</span>
            </div>
        </div>
    </div>

    <!-- Gap between left and right float items -->
    <div class="gap" />

    <!-- Right Floating Items -->
    <div class="right-float">
        <!-- Info Container -->
        <div class="info-container">
            <!-- Info Grids (3x3 Format) -->
            <div class="info-grid">
                <!-- Info Item 1 -->

                <div
                    style="float: right; margin-left: 20px; display: grid; grid-template-columns: repeat(3, 1fr); grid-gap: 20px;"
                    class="info-container"
                >
                    <div class="info-item">
                        <h2>Solar Wind Monitoring</h2>
                        <ul class="data-fields">
                            <li>
                                <span class="bullet" /> Solar Wind Speed: 500 km/s
                            </li>
                            <li>
                                <span class="bullet" /> Solar Wind Density: 5 particles/cm³
                            </li>
                            <li>
                                <span class="bullet" /> Solar Wind Magnetic Field:
                                10 nT
                            </li>
                        </ul>
                    </div>

                    <div class="info-item">
                        <h2>Earth Radiation Budget</h2>
                        <ul class="data-fields">
                            <li>
                                <span class="bullet" /> Earth's Albedo: 0.30
                            </li>
                            <li><span class="bullet" /> Cloud Cover: 40%</li>
                        </ul>
                    </div>

                    <div class="info-item">
                        <h2>Space Weather Alerts</h2>
                        <ul class="data-fields">
                            <li>
                                <span class="bullet" /> Solar Flares: Moderate
                            </li>
                            <li>
                                <span class="bullet" /> Geomagnetic Storms: None
                            </li>
                        </ul>
                    </div>

                    <div class="info-item">
                        <h2>Climate Research</h2>
                        <ul class="data-fields">
                            <li>
                                <span class="bullet" /> Albedo Changes: 0.02 per
                                year
                            </li>
                            <li>
                                <span class="bullet" /> Cloud Cover Patterns: Variable
                            </li>
                        </ul>
                    </div>

                    <div class="info-item">
                        <h2>Atmospheric Measurements</h2>
                        <ul class="data-fields">
                            <li>
                                <span class="bullet" /> Ozone Levels: 300 Dobson
                                Units
                            </li>
                            <li>
                                <span class="bullet" /> Aerosol Concentrations: 15
                                µg/m³
                            </li>
                        </ul>
                    </div>

                    <div class="info-item">
                        <h2>Space Environment Research</h2>
                        <ul class="data-fields">
                            <li><span class="bullet" /> Auroras: Active</li>
                            <li>
                                <span class="bullet" /> Geomagnetic Disturbances:
                                Low
                            </li>
                        </ul>
                    </div>
                </div>
                <!-- Add the remaining Info Items here -->
            </div>
           
        </div>
        
    </div>
    <ul class="additional-data">
        <li class="triangle">Frequency of magnetic reconnection: --</li>
        <li class="triangle">Relation between solar activity and Earth season: --</li>
        <li class="triangle">Relation between solar activity and solar season: --</li>
        <li class="triangle">Solar winds that are easily accessed: --</li>
        <li class="triangle">Earth's magnetosphere: --</li>
    </ul> 
       
</main>

<style>
    /* Add your CSS styles here */
    .dis-sat-container {
        display: flex;
        justify-content: space-between;
    }

    .additional-data {
        list-style-type: none; /* Remove default bullets */
        margin-top: 100px; /* Adjust the margin-top to move the list items down */
        padding-left: 20px; /* Indent the list items */
        color: #fff; /* Text color */
    }

    .additional-data li::before {
        content: "▶"; /* Use a triangle sign as a bullet */
        display: inline-block;
        width: 1em;
        margin-left: -1em; /* Adjust the position of the triangle */
        margin-right: 5px; /* Add spacing between the bullet and text */
        color: red; /* Set the color to red */
    }

    .additional-data li {
        margin-bottom: 15px; /* Adjust the spacing between list items */
    }

    .left-float {
        float: left;
        /* Add styles for left floating items */
    }

    .right-float {
        float: right;
        margin-top: 80px;
    }

    .gap {
        width: 20px; /* Adjust the width of the gap as needed */
        float: left;
    }

    h2 {
        color: #ffcc00;
    }
    /* Add styles for info-container, info-grid, info-item, data-fields, etc. */
</style>
