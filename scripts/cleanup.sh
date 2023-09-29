echo "Starting Cleanup..."
echo "Shutting Down Container and Volumes ⛔"
docker-compose -f docker/docker-compose.yml down
docker volume rm docker_quizz-data
echo "Cleanup Completed! ✅"