using Microsoft.AspNetCore.Mvc;
using SelectPdf;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HtmlToPdfController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> PDF()
        {
            try
            {
                
                    string htmlContent = @"

<!DOCTYPE html>
<html lang='en'>

<head>
    <meta charset='UTF-8' />
    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
    <title>AMPERGIA</title>
    <style>
        * {
            padding: 0;
            margin: 0;
            box-sizing: border-box;
        }

        body {
            font-family: 'Effra', sans-serif;
        }

        .container {
            width: 70vw;
            margin: 0 auto;
            padding: 2rem;
        }

        table {
            width: 100%;
            border-collapse: collapse;
        }

        table img {
            max-width: 100%;
            height: auto;
        }

        table th,
        table td {
            border: none;
            padding: 8px;
            text-align: left;
        }

        /* .container img {
            max-width: 22%;
            height: auto;
        } */

        .container span,
        .date,
        .heading,
        .expo-heading {
            font-size: 1.5rem;
            font-weight: 600;
        }

        .pink-line,
        .pink-line2 {
            background-color: rgb(206, 21, 169);
            height: 0.1rem;
        }

        .pink-line2 {
            width: 50rem;
            margin: 0 auto;
        }

        .ampergia-logo {
            width: 20%;
            /* height: 2.5rem; */
            float: right;
            margin-top: 1rem;
        }

        .pink-img {
            width: 4rem;
        }

        .report-container {
            color: rgb(1, 1, 94);
            clear: both;
            overflow: hidden;
            position: relative;
            height: 80px;
            /* margin-top: 5rem; */
        }

        .report-container>span {
            font-size: 2rem;
            font-weight: 600;
            margin: auto 0;
        }


        .report-container span {
            position: absolute;
            top: 20%;
            /* transform: translateY(-50%); */
            left: 0;
            right: 0;
            margin: auto;
            display: block;
        }

        .report-container img {
            margin-left: 22rem;
        }

        .date {
            color: rgb(1, 1, 94);
            font-size: 1.5rem;
            font-weight: 600;
        }

        .system-info>.heading {
            font-size: 1.5rem;
            font-weight: 700;
        }

        .expo-heading {
            color: rgb(1, 1, 94);
            font-size: 1.5rem;
        }

        .export-container {
            margin-top: 2rem;
            overflow: hidden;
            margin-left: 4rem;
            margin-bottom: 2rem;
        }

        .left {
            float: left;
        }

        .tower {
            width: 5rem;
            float: left;
        }

        .total-export {
            overflow: hidden;
        }

        .euro {
            width: 5rem;
            height: 5rem;
            border: 2px solid rgb(206, 21, 169);
            border-radius: 50%;
            float: left;
            font-size: 3rem;
            color: rgb(206, 21, 169);
            margin-right: 1rem;
            text-align: center;
            line-height: 5rem;
        }

        .export-rev {
            overflow: hidden;
        }

        .export-rev .euro-text{
            margin-top: 1rem;
        }

        .img-container {
            overflow: hidden;
            clear: both;
        }

        .img-container>td>.border {
            width: 15rem;
            height: 15rem;
            border: 2px solid rgb(206, 21, 169);
            margin: 3rem auto;
            border-radius: 50%;
            text-align: center;
            background-color: white;
        }

        .img-container>td>.border>.content {
            position: relative;
            top: 25%;
            /* transform: translateY(-50%); */
        }

        .total-export .tower {
            float: left;
            /* Float the image to the left */
            margin-right: 10px;
            /* Add some space between the image and the data */
        }

        .total-export .data {
            overflow: hidden;
            margin-top: 1rem;
            /* Clear floats */
        }
    </style>
</head>
<script src='https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js'></script>
<body>
    <table>
        <tbody>
            <tr>
                <td>
                    <div class='container'>
                        <table>
                            <tbody>
                                <tr>
                                    <td>
                                        <nav>
                                            <!-- <img src='#' alt='Logo' class='logo' /> -->
                                            <img src='https://voltxdocuments.blob.core.windows.net/houston-corporate-images/HoustonCorporateLogo.png'
                                                alt='' class='ampergia-logo' />
                                        </nav>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class='report-container'>
                                            <span>(Month/Annual) Report</span>
                                            <img src='https://edge-ai-tech.eu/wp-content/uploads/2023/02/EdgeAI_Value-Chains-Circles-VC2_A3_Fit.png'
                                                alt='' class='pink-img' />
                                        </div>

                                        <div>
                                            <canvas id='myChart' style='width:50%;max-width:40%'></canvas>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class='date'>
                                        ${obj.fromDateParts} - ${obj.tillDateParts}
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class='info-container'>
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td class='heading'>System Information:</td>
                                                    </tr>
                                                    <tr>
                                                        <td>${obj.totalConsumption} kW solar PV array</td>
                                                    </tr>
                                                    <tr>
                                                        <td>${obj.energyToday} kW energy storage</td>
                                                    </tr>
                                                    <tr>
                                                        <td>${obj.inverter} kW inverter</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <div class='info-img'>
                                                <img src='./assets/info.png' alt='' class='info-img' />
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class='pink-line2'></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class='expo-heading'>Export to Grid:</td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class='export-container'>
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td class='left'>
                                                            <div class='total-export'>
                                                                <img src='https://img.icons8.com/D71DB1/radio-tower.png'
                                                                    alt='' class='tower' />
                                                                <div class='data'>
                                                                    <div>
                                                                        Total Export: ${obj.pvPlusConsumption}
                                                                    </div>
                                                                    <div>
                                                                        % Export:
                                                                        ${obj.averageOfPvAndConsumption}%
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td class='export-rev'>
                                                            <div class='euro'>£</div>
                                                            <div class='euro-text'>Export Revenue: ${obj.totalRevenue}</div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class='pink-line2'></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class='expo-heading'>Environmental Benefits:</td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class='environment-container'>
                                            <table>
                                                <tbody>
                                                    <tr class='img-container'>
                                                        <td>
                                                            <div class='border'>
                                                                <div class='content'>
                                                                    <img src='https://img.icons8.com/D71DB1/truck--v1.png'
                                                                        alt='' width='50rem' />
                                                                    <div>${obj.standardCoalSaved}</div>
                                                                    <div>Tonnes of Standard</div>
                                                                    <div>Coal Saved</div>
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class='border'>
                                                                <div class='content'>
                                                                    <img src='https://img.icons8.com/D71DB1/factory.png'
                                                                        alt='' width='60rem' />
                                                                    <div>${obj.carbonAvoided}</div>
                                                                    <div>Tonnes of CO2</div>
                                                                    <div>Avoided</div>
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class='border'>
                                                                <div class='content'>
                                                                    <img src='https://img.icons8.com/D71DB1/potted-plant.png'
                                                                        alt='' width='70rem' />
                                                                    <div>${obj.equivalentTreesPlanted}</div>
                                                                    <div>Equivalent Trees</div>
                                                                    <div>Planted</div>
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <script>
        var xValues = ['Italy :12', 'Argentina: 54'];
        var yValues = [55, 49];
        var barColors = [
          '#b91d47',
          '#00aba9'
        ];
        
        new Chart('myChart', {
          type: 'pie',
          data: {
            labels: xValues,
            datasets: [{
              backgroundColor: barColors,
              data: yValues
            }]
          },
          options: {
               legend: {
                    display: true,
                    labels: {
                        fontColor: 'gray',
                    },
                    position:'right'
                },
            title: {
              display: true,
              text: 'World Wide Wine Production 2018'
            }
          }
        });
        </script>
</body>

</html>

";
                    var htmlDocument = new HtmlToPdf();
                    htmlDocument.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
                    htmlDocument.Options.MarginLeft = 1;
                    htmlDocument.Options.MarginRight = 1;
                    htmlDocument.Options.MarginBottom = 1;
                    htmlDocument.Options.PdfPageSize = PdfPageSize.A4;
                    SelectPdf.PdfDocument pdfDocument = htmlDocument.ConvertHtmlString(htmlContent);
                    byte[] pdf = pdfDocument.Save();
                    MemoryStream pdfStream = new MemoryStream(pdf);
                    pdfDocument.Close();

                    return File(pdfStream, "application/pdf", "AWB.pdf");
            }
            catch (Exception ex)
            {
                //await _logger.LogError("TrakingUID -"+id, "SouthKoreaAWBPdf", "Exception: " + ex.Message);
                return StatusCode(500, new { message = "An error occurred. Please try after sometime." });
            }
        }

    }
}
